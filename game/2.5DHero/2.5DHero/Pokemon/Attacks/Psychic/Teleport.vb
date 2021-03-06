Namespace BattleSystem.Moves.Psychic

    Public Class Teleport

        Inherits Attack

        Public Sub New()
            '#Definitions
            Me.Type = New Element(Element.Types.Psychic)
            Me.ID = 100
            Me.OriginalPP = 20
            Me.CurrentPP = 20
            Me.MaxPP = 20
            Me.Power = 0
            Me.Accuracy = 0
            Me.Category = Categories.Status
            Me.ContestCategory = ContestCategories.Cool
            Me.Name = "Teleport"
            Me.Description = "Use it to flee from any wild Pokémon. It can also warp to the last Pokémon Center visited."
            Me.CriticalChance = 1
            Me.IsHMMove = False
            Me.Target = Targets.Self
            Me.Priority = 0
            Me.TimesToAttack = 1
            '#End

            '#SpecialDefinitions
            Me.MakesContact = False
            Me.ProtectAffected = False
            Me.MagicCoatAffected = False
            Me.SnatchAffected = False
            Me.MirrorMoveAffected = True
            Me.KingsrockAffected = False
            Me.CounterAffected = False

            Me.DisabledWhileGravity = False
            Me.UseEffectiveness = False
            Me.ImmunityAffected = False
            Me.HasSecondaryEffect = False
            Me.RemovesFrozen = False

            Me.IsHealingMove = False
            Me.IsRecoilMove = False
            Me.IsPunchingMove = False
            Me.IsDamagingMove = False
            Me.IsProtectMove = False
            Me.IsSoundMove = False

            Me.IsAffectedBySubstitute = True
            Me.IsOneHitKOMove = False
            Me.IsWonderGuardAffected = False
            '#End

            Me.AIField1 = AIField.Support
            Me.AIField2 = AIField.Nothing
        End Sub

        Public Overrides Sub MoveHits(own As Boolean, BattleScreen As BattleScreen)
            If BattleScreen.IsTrainerBattle = True Or BattleScreen.IsRemoteBattle = True Or BattleScreen.IsPVPBattle = True Then
                'Fails due to trainer battle.
                BattleScreen.BattleQuery.Add(New TextQueryObject("But " & Me.Name & " failed!"))
            Else
                Dim p As Pokemon = BattleScreen.OwnPokemon
                If own = False Then
                    p = BattleScreen.OppPokemon
                End If

                Dim smokeBall As Boolean = False
                If Not p.Item Is Nothing Then
                    If p.Item.ID = 106 Then 'SmokeBall
                        smokeBall = True
                    End If
                End If

                If BattleCalculation.CanSwitch(BattleScreen, own) = True Or smokeBall = True Then
                    BattleScreen.BattleQuery.Add(New TextQueryObject(p.GetDisplayName() & " fled from battle!"))
                    BattleScreen.BattleQuery.Add(New EndBattleQueryObject(False))
                Else
                    BattleScreen.BattleQuery.Add(New TextQueryObject("But " & Me.Name & " failed, " & p.GetDisplayName() & " is trapped!"))
                End If
            End If
        End Sub

    End Class

End Namespace